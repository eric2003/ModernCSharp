cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

set( LIBRARY_DIR "d:/work/csharp_work/ModernCSharp/codes/dll/createdll/01/build/Debug" )

add_executable( ${PROJECT_NAME} )

set_target_properties( ${PROJECT_NAME} PROPERTIES
    VS_DOTNET_REFERENCE_MyDll ${LIBRARY_DIR}/MyDll.dll)

target_sources( ${PROJECT_NAME}
    PRIVATE
        main.cs
)
