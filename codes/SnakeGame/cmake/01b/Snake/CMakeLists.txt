cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

include(CSharpUtilities)

add_executable( testprj )

target_sources( testprj
    PRIVATE
        Position.cs
		Images.cs
		GridValue.cs
		GameState.cs
		Direction.cs
		#AssemblyInfo.cs
		App.xaml.cs
		MainWindow.xaml.cs
)

csharp_set_xaml_cs_properties(
    App.xaml
	App.xaml.cs
	MainWindow.xaml
	MainWindow.xaml.cs
)


# Set the C# language version for all projects.
SET(CMAKE_CSharp_FLAGS "/langversion:9")

#set_target_properties(${PROJECT_NAME} PROPERTIES
#    DOTNET_SDK "Microsoft.NET.Sdk"
#    DOTNET_TARGET_FRAMEWORK "net80"
#)

LIST(APPEND VS_DOTNET_REFERENCES "Microsoft.CSharp")
LIST(APPEND VS_DOTNET_REFERENCES "PresentationCore")
LIST(APPEND VS_DOTNET_REFERENCES "PresentationFramework")
LIST(APPEND VS_DOTNET_REFERENCES "System")
LIST(APPEND VS_DOTNET_REFERENCES "System.Data")
LIST(APPEND VS_DOTNET_REFERENCES "System.Threading.Tasks")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xaml")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xml")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xml.Linq")
LIST(APPEND VS_DOTNET_REFERENCES "WindowsBase")

set_target_properties(${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCES "${VS_DOTNET_REFERENCES}"
)

