// Rezolucja.cs
//	
// Author:
//   [NAME] [EMAIL]
//
// Copyright (c) 2008, [OWNER]
//
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//    * Neither the name of the [ORGANIZATION] nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
// EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
//

using System;
	
using System.Text.RegularExpressions;
using NUnit.Framework;
using org.drools.dotnet.compiler;
using org.drools.dotnet.rule;
using org.drools.dotnet;
using System.Reflection;
using System.Text;

namespace sldlib
{
	
	[TestFixture]
	public class Rezolucja
	{
		
		public Rezolucja()
		{
		}
		public void Run() {
			
			Regex rx = new Regex(@"([a-z][a-z0-9]*)\(([a-zA-Z0-9]+),?([a-zA-Z0-9]+)?\)");
			WorkingMemory wm = Laduj("rezolucja2.drl");
			string[] str = {"lubi(ola,ela),hmm(B,G)","lubi(G,H),kolezanki(G,H),costam(H,G)"};
			int nf  = 0;
			int np = 0;
			foreach (string s in str) {
				Match m = rx.Match(s);
				while (m.Success) {
					GroupCollection gc = m.Groups;
					
					if (gc[3].Value == "") {
						Predykat p = new Predykat(gc[1].Value,gc[2].Value,nf,np);
						Console.WriteLine("Nazwa: {0}, arg1: {1}, nf: {2}, np: {3}",p.symbol,p.arg1,p.nf,p.np); 
						if (p.var1)
						{
							Console.WriteLine("zmienna");
						}
						else {
							Console.WriteLine("stala");
						}
						wm.assertObject(p);
						
					}
					else {
						Predykat p = new Predykat(gc[1].Value,gc[2].Value,gc[3].Value,nf,np);
						Console.WriteLine("Nazwa: {0}, arg1: {1}, arg2: {2}, nf: {3}, np: {4}",p.symbol,p.arg1, p.arg2,p.nf,p.np);
						wm.assertObject(p);
					}
					np ++;	
					m = m.NextMatch();
				}
				Predykat e = new Predykat("__end",nf,np);
				wm.assertObject(e);
				np = 0;
				nf++;
			}
			wm.assertObject(new Vars(0,0));
			wm.fireAllRules();
			
		}
		[Test]
		public WorkingMemory Laduj(string drlname) {
			System.IO.Stream stream = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream(drlname);
			PackageBuilder builder = new PackageBuilder();
			builder.AddPackageFromDrl(stream);
			Package pkg = builder.GetPackage();
			RuleBase ruleBase = RuleBaseFactory.NewRuleBase();
			ruleBase.AddPackage(pkg);
			WorkingMemory workingMemory = ruleBase.NewWorkingMemory();	
			return workingMemory;
		}
	}
	
	public class Predykat {
		
		private string nazwastr;
		private string arg1str = null;
		private string arg2str = null;
		private int argcint;
		private int nfint; /* numer formuly 0 == formula sprawdzana */
		private int npint; /* numer predykatu w formule - 0 == zanegowany */
		private bool v1 = false;
		private bool v2 = false;
		private int clint;
		
		public Predykat(string n, int f, int p)
		{
			this.nazwastr = n;
			this.nfint = f;
			this.npint = p;
			this.argcint = 0;
			this.clint = 0;
		}
		
		public Predykat(string n, string a1, string a2, int f, int p) {
			this.nazwastr = n;
			this.arg1str = a1;
			this.arg2str = a2;
			this.nfint = f;
			this.npint = p;
			this.argcint = 2;
			this.clint = 0;
			if (!char.IsLower(this.arg1str[0])) {
				this.v1 = true;
			}
			if (!char.IsLower(this.arg2str[0])) {
				this.v2 = true;
			}
		}
		
		public Predykat(string n, string a1, int f, int p) {
			this.nazwastr = n;
			this.arg1str = a1;
			this.nfint = f;
			this.npint = p;
			this.argcint = 1;
			this.clint = 0;
			if (!char.IsLower(this.arg1str[0])) {
				this.v1 = true;
			}
		}
		
		public string symbol {
			set {this.nazwastr = value;}
			get {return this.nazwastr;}
		}
		
		public string arg1 {
			set {this.arg1str = value;}
			get {return this.arg1str;}
		}
		
		public string arg2 {
			set {
				if (this.argcint == 2) {
					this.arg2str = value;
				}
			}
			get {return this.arg2str;}
		}
		
		public int argc {
			get {return this.argcint;}
			set {this.argcint = value;}
		}
		
		public int nf {
			set {this.nfint = value;}
			get {return this.nfint;}
		}
		
		public int np {
			set {this.npint = value;}
			get {return this.npint;}
		}
		
		public bool var1 {
			get {return this.v1;}
		}
		
		public bool var2 {
			get {return this.v2;}
		}
		
		public int cl {
			get {return this.clint;}
			set {this.clint = value;}
		
		}
	}
	
	public class Vars {
		
		private int fint; // indeks formuły sprawdzanej
		private int pint;
		private int ufint; // indeks formuły unifikowanej
		private int nextint =  1;
		private int lastint = 0; // indeks ostatniego predykatu w rezolwencie
		
		public Vars(int f, int p) {
			this.fint = f;
			this.pint = p;
		}
		
		public int last {
			get {return this.lastint;}
			set {this.lastint = value;}
		}
		
		public int next {
			get {return this.nextint;}
			set {this.nextint = value;}
		}
		
		public int nf {
			
			get {return this.fint;}
			set {this.fint = value;}
		}
		
		public int np {
			get {return this.pint;}
			set {this.pint = value;}
		}
		
		public int cform {
			get {return this.ufint;}
			set {this.ufint = value;}
		}
		
		
	}
	
	public class Unifikator {
		
		private string var1str;
		private string var2str;
		private string sub1str;
		private string sub2str;
		private int kint;
		
		public Unifikator(string v1, string v2, string s1, string s2) {
			this.var1str = v1;
			this.var2str = v2;
			this.sub1str = s1;
			this.sub2str = s2;
			this.kint = 0;
		}
		
		public int krok {
			get {return this.kint;}
			set {this.kint = value;}
		}
		
		public string var2 {
			get {return this.var2str;}
			set {this.var2str = value;}
		}
		
		public string sub1 {
			get {return this.sub1str;}
			set {this.sub1str = value;}
		}
		
		public string sub2 {
			get {return this.sub2str;}
			set {this.sub2str = value;}
		}
		
		public string var1 {
			get {return this.var1str;}
			set {this.var1str = value;}
		}
	}
}
