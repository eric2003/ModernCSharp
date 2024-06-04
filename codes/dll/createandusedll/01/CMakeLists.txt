cmake_minimum_required(VERSION 3.29)

project(mainprj)

enable_language(CSharp)

add_library( MyDllLib SHARED )

target_sources( MyDllLib
    PRIVATE
        MyDll.cs
)

add_executable( mainprj )

target_sources( mainprj
    PRIVATE
        main.cs
)		


target_link_libraries( mainprj 
	private
		MyDllLib
)

