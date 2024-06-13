project(TicTacToe VERSION 1.0.0.0)

include(CSharpUtilities)

message(STATUS "PROJECT_NAME=${PROJECT_NAME}")

set( AssemblyInfoFile "${CMAKE_BINARY_DIR}/Config/${PROJECT_NAME}/AssemblyInfo.cs" )

# Create assembly info with current version.
configure_file("${CMAKE_SOURCE_DIR}/AssemblyInfo.cs.template" ${AssemblyInfoFile})

set( AssetDIR ../../Assets )

set( IMAGE_RESOURCES
	"${AssetDIR}/Icon.ico"
	"${AssetDIR}/Grid.png"
	"${AssetDIR}/O0.png"
	"${AssetDIR}/O1.png"
	"${AssetDIR}/O2.png"
	"${AssetDIR}/O3.png"
	"${AssetDIR}/O4.png"
	"${AssetDIR}/O5.png"
	"${AssetDIR}/O6.png"
	"${AssetDIR}/O7.png"
	"${AssetDIR}/O8.png"
	"${AssetDIR}/O9.png"
	"${AssetDIR}/O10.png"
	"${AssetDIR}/O11.png"
	"${AssetDIR}/O12.png"
	"${AssetDIR}/O13.png"
	"${AssetDIR}/O14.png"
	"${AssetDIR}/O15.png"
	"${AssetDIR}/X0.png"
	"${AssetDIR}/X1.png"
	"${AssetDIR}/X2.png"
	"${AssetDIR}/X3.png"
	"${AssetDIR}/X4.png"
	"${AssetDIR}/X5.png"
	"${AssetDIR}/X6.png"
	"${AssetDIR}/X7.png"
	"${AssetDIR}/X8.png"
	"${AssetDIR}/X9.png"
	"${AssetDIR}/X10.png"
	"${AssetDIR}/X11.png"
	"${AssetDIR}/X12.png"
	"${AssetDIR}/X13.png"
	"${AssetDIR}/X14.png"
	"${AssetDIR}/X15.png"	
)

# Set the C# language version for all projects.
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
		Player.cs
		WinType.cs
		WinInfo.cs
		GameResult.cs
		GameState.cs
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



