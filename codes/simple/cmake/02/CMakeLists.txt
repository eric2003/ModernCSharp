cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

add_executable(${PROJECT_NAME})

target_sources( ${PROJECT_NAME}
    PRIVATE
        FileA.cs
		FileB.cs
)
