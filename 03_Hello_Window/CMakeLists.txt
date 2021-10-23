cmake_minimum_required(VERSION 3.0.0)
project(HelloWindow VERSION 0.1.0)

include(CTest)
enable_testing()

add_executable(HelloWindow main.cpp)

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)

find_package(OpenGL REQUIRED)

add_library(glad STATIC IMPORTED)
set_target_properties(
        glad
        PROPERTIES IMPORTED_LOCATION
        ${CMAKE_CURRENT_LIST_DIR}/../glad/build/libglad.a
)

include_directories(
    ${CMAKE_CURRENT_LIST_DIR}/../glad/build/include/
)

target_link_libraries(
    HelloWindow
    glfw
    GLU
    glad
    OpenGL::GL
    dl
)