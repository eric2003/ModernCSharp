project(PacMan VERSION 1.0.0.0)

# Include CMake utilities for CSharp, for WinForm and WPF application support.
include(CSharpUtilities)

message(STATUS "PROJECT_NAME=${PROJECT_NAME}")

set( AssemblyInfoFile "${CMAKE_BINARY_DIR}/Config/${PROJECT_NAME}/AssemblyInfo.cs" )

# Create assembly info with current version.
configure_file("${CMAKE_SOURCE_DIR}/AssemblyInfo.cs.template" ${AssemblyInfoFile})

# Define the executable, including any .cs files. 
# The .resx and other Properties files are optional here, but including them makes them visible in the VS solution for easy editing. 

add_executable( ${PROJECT_NAME} )

target_sources( ${PROJECT_NAME}
	PRIVATE
		${AssemblyInfoFile}
		Form1.cs
		Form1.Designer.cs
		Program.cs
)

# Set the .NET Framework version for the executable.
#set_property(TARGET ${PROJECT_NAME} PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.6.1")
# Set the executable to be 32-bit.
#set_property(TARGET ${PROJECT_NAME} PROPERTY WIN32_EXECUTABLE TRUE)
# Set the C# language version (defaults to 3.0).
set(CMAKE_CSharp_FLAGS "/langversion:latest")

# Set the source file properties for Windows Forms use.
csharp_set_windows_forms_properties(
    Form1.cs
    Form1.Designer.cs
    Program.cs
	${AssemblyInfoFile}
)

# If necessary, link in other library dependencies that were built locally in this source tree.
#target_link_libraries(MyWinFormApp MyLocalLib)

# If necessary, link in other library/DLL references, such as 3rd party libraries.
#set_property(TARGET MyWinFormApp PROPERTY 
#    VS_DOTNET_REFERENCE_MyThirdPartyLib /path/to/libs/MyThirdPartyLib.dll)

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