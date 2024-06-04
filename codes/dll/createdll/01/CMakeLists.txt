cmake_minimum_required(VERSION 3.29)

project(testprj)

enable_language(CSharp)

add_library( MyDll SHARED )

target_sources( MyDll
    PRIVATE
        MyDll.cs

)
