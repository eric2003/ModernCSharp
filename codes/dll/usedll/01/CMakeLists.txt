cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

set ( PRJ_LIBRARIES )

list ( APPEND PRJ_LIBRARIES "d:/work/csharp_work/ModernCSharp/codes/dll/createdll/01/build/Debug/MyDll.dll" )

add_executable(${PROJECT_NAME})

target_sources( ${PROJECT_NAME}
    PRIVATE
        main.cs
)

target_link_libraries ( ${PROJECT_NAME} 
    PRIVATE 
        ${PRJ_LIBRARIES}
)

