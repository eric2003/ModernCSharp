cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

set ( PRJ_LIBRARIES )

list ( APPEND PRJ_LIBRARIES ${LIBRARY_DIR}/MyDll.dll )

set( LIBRARY_DIR ${CMAKE_CURRENT_SOURCE_DIR} )


add_executable(${PROJECT_NAME})

set_property(TARGET ${PROJECT_NAME} PROPERTY 
    VS_DOTNET_REFERENCE_MyDll ${LIBRARY_DIR}/MyDll.dll)


target_sources( ${PROJECT_NAME}
    PRIVATE
        main.cs
)

target_link_libraries ( ${PROJECT_NAME} 
    PRIVATE 
        ${PRJ_LIBRARIES}
)