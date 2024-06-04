cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

SET(CMAKE_CSharp_FLAGS "/langversion:8")
#SET(CMAKE_CSharp_FLAGS "${CMAKE_CSharp_FLAGS} /nullable:enable")

add_executable( ${PROJECT_NAME} )

target_sources( ${PROJECT_NAME}
    PRIVATE
        main.cs
)

target_compile_options( ${PROJECT_NAME} 
	PRIVATE 
	"/nullable:enable"
)
