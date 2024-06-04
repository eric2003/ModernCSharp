cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

include(CSharpUtilities)

add_executable( testprj )

target_sources( testprj
    PRIVATE
		AssemblyInfo.cs
		App.xaml
		App.xaml.cs
		MainWindow.xaml
		MainWindow.xaml.cs
)

csharp_set_xaml_cs_properties(
    App.xaml
	App.xaml.cs
	MainWindow.xaml
	MainWindow.xaml.cs
)

# Set the C# language version for all projects.
#SET(CMAKE_CSharp_FLAGS "/langversion:8")


set_target_properties(${PROJECT_NAME} PROPERTIES
    DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2"
)

set_source_files_properties(App.xaml
                            PROPERTIES 
                            VS_XAML_TYPE "ApplicationDefinition")
							
							
							
LIST(APPEND VS_DOTNET_REFERENCES "WindowsBase")
LIST(APPEND VS_DOTNET_REFERENCES "PresentationCore")
LIST(APPEND VS_DOTNET_REFERENCES "PresentationFramework")
LIST(APPEND VS_DOTNET_REFERENCES "System.Data")
LIST(APPEND VS_DOTNET_REFERENCES "System")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xaml")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xml")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Windows")




#LIST(APPEND VS_DOTNET_REFERENCES "Microsoft.CSharp")
#LIST(APPEND VS_DOTNET_REFERENCES "PresentationCore")
#LIST(APPEND VS_DOTNET_REFERENCES "PresentationFramework")
#LIST(APPEND VS_DOTNET_REFERENCES "System")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Core" )
#LIST(APPEND VS_DOTNET_REFERENCES "System.Data")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Data.DataSetExtensions")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Collections")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Collections.Generic")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Threading.Tasks")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Xaml")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Xml")
#LIST(APPEND VS_DOTNET_REFERENCES "System.Xml.Linq")
#LIST(APPEND VS_DOTNET_REFERENCES "WindowsBase")


set_target_properties(${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCES "${VS_DOTNET_REFERENCES}"
)

