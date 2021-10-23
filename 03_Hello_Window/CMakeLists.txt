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

add_library(soil STATIC IMPORTED)
set_target_properties(
        soil
        PROPERTIES IMPORTED_LOCATION
        ${CMAKE_CURRENT_LIST_DIR}/../SOIL2/lib/linux/libsoil2.a
)

include_directories(
    ${CMAKE_CURRENT_LIST_DIR}/../SOIL2/src/SOIL2/
    ${CMAKE_CURRENT_LIST_DIR}/../glad/build/include/
    ${CMAKE_CURRENT_LIST_DIR}/../stb/
)

target_link_libraries(
    HelloWindow
    glfw
    soil
    GLU
    glad
    OpenGL::GL
    dl
)