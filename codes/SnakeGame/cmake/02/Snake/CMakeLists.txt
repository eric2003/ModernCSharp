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
		App.xaml
		App.xaml.cs
		MainWindow.xaml
		MainWindow.xaml.cs
		${IMAGE_RESOURCES}
)

csharp_set_xaml_cs_properties(
    App.xaml
	App.xaml.cs
	MainWindow.xaml
	MainWindow.xaml.cs
)

SET(IMAGE_RESOURCES
    "Assets/Body.png"
    "Assets/DeadBody.png"
	"Assets/DeadHead.png"
	"Assets/Empty.png"
	"Assets/Food.png"
	"Assets/Head.png"
	"Assets/Head.png"
	"Assets/icon.ico"
	"DroidSansMono.ttf"
)

SET_SOURCE_FILES_PROPERTIES(${IMAGE_RESOURCES} PROPERTIES VS_TOOL_OVERRIDE "Resource")


# Set the C# language version for all projects.
SET(CMAKE_CSharp_FLAGS "/langversion:9")
SET(CMAKE_CSharp_FLAGS "${CMAKE_CSharp_FLAGS} /platform:AnyCPU")

set_source_files_properties(App.xaml
                            PROPERTIES 
                            VS_XAML_TYPE "ApplicationDefinition")

set_target_properties(${PROJECT_NAME} PROPERTIES
    DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2"
)


LIST(APPEND VS_DOTNET_REFERENCES "Microsoft.CSharp")
LIST(APPEND VS_DOTNET_REFERENCES "PresentationCore")
LIST(APPEND VS_DOTNET_REFERENCES "PresentationFramework")
LIST(APPEND VS_DOTNET_REFERENCES "System")
LIST(APPEND VS_DOTNET_REFERENCES "System.Core" )
LIST(APPEND VS_DOTNET_REFERENCES "System.Data")
LIST(APPEND VS_DOTNET_REFERENCES "System.Data.DataSetExtensions")
LIST(APPEND VS_DOTNET_REFERENCES "System.Collections")
LIST(APPEND VS_DOTNET_REFERENCES "System.Collections.Generic")
LIST(APPEND VS_DOTNET_REFERENCES "System.Threading.Tasks")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xaml")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xml")
LIST(APPEND VS_DOTNET_REFERENCES "System.Xml.Linq")
LIST(APPEND VS_DOTNET_REFERENCES "WindowsBase")


set_target_properties(${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCES "${VS_DOTNET_REFERENCES}"
)

