project(MyCanvasPrj VERSION 1.0.1.2)

include(CSharpUtilities)

message(STATUS "PROJECT_NAME=${PROJECT_NAME}")

set( AssemblyInfoFile "${CMAKE_BINARY_DIR}/Config/${PROJECT_NAME}/AssemblyInfo.cs" )

# Create assembly info with current version.
configure_file("${CMAKE_SOURCE_DIR}/AssemblyInfo.cs.template" ${AssemblyInfoFile})

# Set the C# language version for all projects.
set(CMAKE_CSharp_FLAGS "/langversion:9")

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


list(APPEND VS_DOTNET_REFERENCES "PresentationCore")
list(APPEND VS_DOTNET_REFERENCES "PresentationFramework")
list(APPEND VS_DOTNET_REFERENCES "WindowsBase")
list(APPEND VS_DOTNET_REFERENCES "System")
list(APPEND VS_DOTNET_REFERENCES "System.Data")
list(APPEND VS_DOTNET_REFERENCES "System.Xaml")


set_target_properties(${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCES "${VS_DOTNET_REFERENCES}"
)

# Set CLR assembly properties.
set_target_properties( ${PROJECT_NAME} PROPERTIES
    VS_GLOBAL_ROOTNAMESPACE ${PROJECT_NAME}
)



