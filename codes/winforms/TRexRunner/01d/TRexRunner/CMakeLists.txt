cmake_minimum_required(VERSION 3.29)

project(TRexRunner VERSION 1.0.0.0)

enable_language(CSharp)

# Include CMake utilities for CSharp, for WinForm and WPF application support.
include(CSharpUtilities)

message(STATUS "PROJECT_NAME=${PROJECT_NAME}")

set( AssetDIR Assets )

set( IMAGE_RESOURCES
	"${AssetDIR}/dead.png"
	"${AssetDIR}/obstacle-1.gif"
	"${AssetDIR}/obstacle-2.gif"
	"${AssetDIR}/running.gif"
)

set_source_files_properties(${IMAGE_RESOURCES}
                           PROPERTIES 
						   VS_TOOL_OVERRIDE "Resource")

add_executable( ${PROJECT_NAME} )

target_sources( ${PROJECT_NAME}
	PRIVATE
         Form1.cs
         Form1.Designer.cs
         Program.cs
	     Form1.resx
		 ${IMAGE_RESOURCES}
		 Properties/Resources.Designer.cs
		 Properties/Resources.resx		 
)

set_target_properties(${PROJECT_NAME} PROPERTIES
	DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2"
	)
	
set(CMAKE_CSharp_FLAGS "/langversion:latest")

# Set the source file properties for Windows Forms use.
csharp_set_windows_forms_properties(
    Form1.cs
    Form1.Designer.cs
    Program.cs
	Form1.resx
	Properties/Resources.Designer.cs
	Properties/Resources.resx	
)



# Add in the .NET reference libraries.
list(APPEND VS_DOTNET_REFERENCES "Microsoft.CSharp")
list(APPEND VS_DOTNET_REFERENCES "System")
list(APPEND VS_DOTNET_REFERENCES "System.Core")
list(APPEND VS_DOTNET_REFERENCES "System.Data")
list(APPEND VS_DOTNET_REFERENCES "System.Drawing")
list(APPEND VS_DOTNET_REFERENCES "System.Windows.Forms")


set_target_properties(${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCES "${VS_DOTNET_REFERENCES}"
)

# Set CLR assembly properties.
set_target_properties( ${PROJECT_NAME} PROPERTIES
    VS_GLOBAL_ROOTNAMESPACE ${PROJECT_NAME}
)