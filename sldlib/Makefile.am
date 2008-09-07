
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ -debug "-define:DEBUG"

ASSEMBLY = bin/Debug/sldlib.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

NUNIT_FRAMEWORK_DLL_SOURCE=../ddn/nunit.framework.dll
IKVM_RUNTIME_DLL_SOURCE=../ddn/IKVM.Runtime.dll
DROOLS_DOTNET_DLL_SOURCE=../ddn/drools.dotnet.dll
DROOLS_DEP_DLL_SOURCE=../ddn/drools-dep.dll
IKVM_GNU_CLASSPATH_DLL_SOURCE=../ddn/IKVM.GNU.Classpath.dll
DROOLS_3_0_DLL_SOURCE=../ddn/drools-3.0.dll

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/sldlib.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

NUNIT_FRAMEWORK_DLL_SOURCE=../ddn/nunit.framework.dll
IKVM_RUNTIME_DLL_SOURCE=../ddn/IKVM.Runtime.dll
DROOLS_DOTNET_DLL_SOURCE=../ddn/drools.dotnet.dll
DROOLS_DEP_DLL_SOURCE=../ddn/drools-dep.dll
IKVM_GNU_CLASSPATH_DLL_SOURCE=../ddn/IKVM.GNU.Classpath.dll
DROOLS_3_0_DLL_SOURCE=../ddn/drools-3.0.dll

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=.resources.dll

PROGRAMFILES = \
	$(NUNIT_FRAMEWORK_DLL) \
	$(IKVM_RUNTIME_DLL) \
	$(DROOLS_DOTNET_DLL) \
	$(DROOLS_DEP_DLL) \
	$(IKVM_GNU_CLASSPATH_DLL) \
	$(DROOLS_3_0_DLL)  

LINUX_PKGCONFIG = \
	$(SLDLIB_PC)  


	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	MyClass.cs \
	AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = \
	../rezolucja2.drl 

EXTRAS = \
	Rezolucja.cs \
	sldlib.pc.in 

REFERENCES =  \
	System

DLL_REFERENCES =  \
	../ddn/drools-3.0.dll \
	../ddn/drools-dep.dll \
	../ddn/IKVM.GNU.Classpath.dll \
	../ddn/IKVM.Runtime.dll \
	../ddn/nunit.framework.dll \
	../ddn/drools.dotnet.dll

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

SLDLIB_PC = $(BUILD_DIR)/sldlib.pc
NUNIT_FRAMEWORK_DLL = $(BUILD_DIR)/nunit.framework.dll
IKVM_RUNTIME_DLL = $(BUILD_DIR)/IKVM.Runtime.dll
DROOLS_DOTNET_DLL = $(BUILD_DIR)/drools.dotnet.dll
DROOLS_DEP_DLL = $(BUILD_DIR)/drools-dep.dll
IKVM_GNU_CLASSPATH_DLL = $(BUILD_DIR)/IKVM.GNU.Classpath.dll
DROOLS_3_0_DLL = $(BUILD_DIR)/drools-3.0.dll

$(eval $(call emit-deploy-wrapper,SLDLIB_PC,sldlib.pc))
$(eval $(call emit-deploy-target,NUNIT_FRAMEWORK_DLL))
$(eval $(call emit-deploy-target,IKVM_RUNTIME_DLL))
$(eval $(call emit-deploy-target,DROOLS_DOTNET_DLL))
$(eval $(call emit-deploy-target,DROOLS_DEP_DLL))
$(eval $(call emit-deploy-target,IKVM_GNU_CLASSPATH_DLL))
$(eval $(call emit-deploy-target,DROOLS_3_0_DLL))


$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(build_resx_resources) : %.resources: %.resx
	resgen2 '$<' '$@'

$(ASSEMBLY) $(ASSEMBLY_MDB): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(dir $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
