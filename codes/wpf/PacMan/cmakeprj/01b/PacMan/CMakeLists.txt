cmake_minimum_required(VERSION 3.29)

project(PacMan VERSION 1.0.0.0)

enable_language(CSharp)

# Include CMake utilities for CSharp, for WinForm and WPF application support.
include(CSharpUtilities)

message(STATUS "PROJECT_NAME=${PROJECT_NAME}")

set( AssetDIR Assets )

set( IMAGE_RESOURCES
	#"${AssetDIR}/coin.gif"
)
	
set(CMAKE_CSharp_FLAGS "/langversion:latest")

set_source_files_properties(${IMAGE_RESOURCES} 
                           PROPERTIES 
						   VS_TOOL_OVERRIDE "Resource")

set_source_files_properties(App.xaml
                            PROPERTIES 
                            VS_XAML_TYPE "ApplicationDefinition")

add_executable( ${PROJECT_NAME} )

target_sources( ${PROJECT_NAME}
    PRIVATE
		${AssemblyInfoFile}
		App.xaml
		App.xaml.cs
		MainWindow.xaml
		MainWindow.xaml.cs
		${IMAGE_RESOURCES}
)

# Set designer and XAML properties.
csharp_set_designer_cs_properties(
    "${AssemblyInfoFile}"
)

csharp_set_xaml_cs_properties(
	"App.xaml"
	"App.xaml.cs"
	"MainWindow.xaml"
    "MainWindow.xaml.cs"
)


LIST(APPEND VS_DOTNET_REFERENCES "PresentationCore")
LIST(APPEND VS_DOTNET_REFERENCES "PresentationFramework")
LIST(APPEND VS_DOTNET_REFERENCES "WindowsBase")
LIST(APPEND VS_DOTNET_REFERENCES "System")
LIST(APPEND VS_DOTNET_REFERENCES "System.Data")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xaml")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Core" )

set_target_properties(${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCES "${VS_DOTNET_REFERENCES}"
)

# Set CLR assembly properties.
set_target_properties( ${PROJECT_NAME} PROPERTIES
    VS_GLOBAL_ROOTNAMESPACE ${PROJECT_NAME}
)
