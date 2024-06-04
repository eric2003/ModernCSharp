cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

set(CMAKE_CSharp_FLAGS "/nullable:enable")

add_executable( ${PROJECT_NAME} )

target_sources( ${PROJECT_NAME}
    PRIVATE
        main.cs
)
