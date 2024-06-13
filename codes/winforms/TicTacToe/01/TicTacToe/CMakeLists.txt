project(TicTacToe VERSION 1.0.0.0)

include(CSharpUtilities)

message(STATUS "PROJECT_NAME=${PROJECT_NAME}")

set( AssemblyInfoFile "${CMAKE_BINARY_DIR}/Config/${PROJECT_NAME}/AssemblyInfo.cs" )

# Create assembly info with current version.
configure_file("${CMAKE_SOURCE_DIR}/AssemblyInfo.cs.template" ${AssemblyInfoFile})

# Set the C# language version for all projects.
set(CMAKE_CSharp_FLAGS "/langversion:9")

add_executable( ${PROJECT_NAME} )

target_sources( ${PROJECT_NAME}
    PRIVATE
		${AssemblyInfoFile}
		Form1.cs
		Form1.Designer.cs
		Program.cs
)

# Set Windows Forms properties
csharp_set_windows_forms_properties(
     Form1.cs
     Form1.Designer.cs
     Program.cs
    "${AssemblyInfoFile}"
)


# Set designer and roperties.
csharp_set_designer_cs_properties(
    "${AssemblyInfoFile}"
)

#list(APPEND VS_DOTNET_REFERENCES "PresentationCore")
#list(APPEND VS_DOTNET_REFERENCES "PresentationFramework")
#list(APPEND VS_DOTNET_REFERENCES "WindowsBase")
list(APPEND VS_DOTNET_REFERENCES "System")
list(APPEND VS_DOTNET_REFERENCES "System.Core")
list(APPEND VS_DOTNET_REFERENCES "System.Data")
list(APPEND VS_DOTNET_REFERENCES "System.Drawing")
list(APPEND VS_DOTNET_REFERENCES "System.Windows.Forms")
list(APPEND VS_DOTNET_REFERENCES "Microsoft.CSharp")



set_target_properties(${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCES "${VS_DOTNET_REFERENCES}"
)

# Set CLR assembly properties.
set_target_properties( ${PROJECT_NAME} PROPERTIES
    VS_GLOBAL_ROOTNAMESPACE ${PROJECT_NAME}
)



