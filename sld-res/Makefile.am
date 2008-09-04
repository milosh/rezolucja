
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ -debug "-define:DEBUG"

ASSEMBLY = bin/Debug/sld-res.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../sldlib/bin/Debug/sldlib.dll
BUILD_DIR = bin/Debug

NUNIT_FRAMEWORK_DLL_SOURCE=../ddn/nunit.framework.dll
IKVM_RUNTIME_DLL_SOURCE=../ddn/IKVM.Runtime.dll
SLDLIB_DLL_MDB_SOURCE=../sldlib/bin/Debug/sldlib.dll.mdb
SLDLIB_DLL_MDB=$(BUILD_DIR)/sldlib.dll.mdb
DROOLS_DOTNET_DLL_SOURCE=../ddn/drools.dotnet.dll
SLDLIB_DLL_SOURCE=../sldlib/bin/Debug/sldlib.dll
DROOLS_DEP_DLL_SOURCE=../ddn/drools-dep.dll
IKVM_GNU_CLASSPATH_DLL_SOURCE=../ddn/IKVM.GNU.Classpath.dll
DROOLS_3_0_DLL_SOURCE=../ddn/drools-3.0.dll

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/sld-res.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../sldlib/bin/Release/sldlib.dll
BUILD_DIR = bin/Release

NUNIT_FRAMEWORK_DLL_SOURCE=../ddn/nunit.framework.dll
IKVM_RUNTIME_DLL_SOURCE=../ddn/IKVM.Runtime.dll
SLDLIB_DLL_MDB=
DROOLS_DOTNET_DLL_SOURCE=../ddn/drools.dotnet.dll
SLDLIB_DLL_SOURCE=../sldlib/bin/Release/sldlib.dll
DROOLS_DEP_DLL_SOURCE=../ddn/drools-dep.dll
IKVM_GNU_CLASSPATH_DLL_SOURCE=../ddn/IKVM.GNU.Classpath.dll
DROOLS_3_0_DLL_SOURCE=../ddn/drools-3.0.dll

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=.resources.dll

PROGRAMFILES = \
	$(NUNIT_FRAMEWORK_DLL) \
	$(IKVM_RUNTIME_DLL) \
	$(SLDLIB_DLL_MDB) \
	$(DROOLS_DOTNET_DLL) \
	$(SLDLIB_DLL) \
	$(DROOLS_DEP_DLL) \
	$(IKVM_GNU_CLASSPATH_DLL) \
	$(DROOLS_3_0_DLL)  

BINARIES = \
	$(SLD_RES)  


	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Main.cs \
	AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = \
	../unifikacja.drl 

EXTRAS = \
	sld-res.in 

REFERENCES =  \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

SLD_RES = $(BUILD_DIR)/sld-res
NUNIT_FRAMEWORK_DLL = $(BUILD_DIR)/nunit.framework.dll
IKVM_RUNTIME_DLL = $(BUILD_DIR)/IKVM.Runtime.dll
DROOLS_DOTNET_DLL = $(BUILD_DIR)/drools.dotnet.dll
SLDLIB_DLL = $(BUILD_DIR)/sldlib.dll
DROOLS_DEP_DLL = $(BUILD_DIR)/drools-dep.dll
IKVM_GNU_CLASSPATH_DLL = $(BUILD_DIR)/IKVM.GNU.Classpath.dll
DROOLS_3_0_DLL = $(BUILD_DIR)/drools-3.0.dll

$(eval $(call emit-deploy-wrapper,SLD_RES,sld-res,x))
$(eval $(call emit-deploy-target,NUNIT_FRAMEWORK_DLL))
$(eval $(call emit-deploy-target,IKVM_RUNTIME_DLL))
$(eval $(call emit-deploy-target,SLDLIB_DLL_MDB))
$(eval $(call emit-deploy-target,DROOLS_DOTNET_DLL))
$(eval $(call emit-deploy-target,SLDLIB_DLL))
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
