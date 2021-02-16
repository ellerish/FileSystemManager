# File System Manager
C# Console Application to manage and manipulate files. Resouces provided.
The solution is implemented in C# using a Console Application in Visual Studio.

## Table of Contents
- [Install](#install)
- [Usage](#usage)
- [Maintainers](#maintainers)

## Install
- Clone 
- Open in Visual Studio
- Build the application

## Usage
- Run the application from Visual Studio.

## Maintainers
- Elise Rishaug

## Features

### Menu 
Provides the user with various options and checks for valid user inputs. The options match the 
functionality of the file service.

### FileService
Fileservice gather information about files in the project located in a resource folder.
Functionality: 
- List all the files (Filename).
- Get spesific files by their extension
- Manipulate Dracula.txt found in resource folder
  - Get name of file 
  - How big the file is
  - How many lines the files has
  - How many times a specific word provided by user is found in the file. 

### LogBase: FileLogger
Logs(writes) to file ("log.txt") found in Log folder
Logs all the results from fileservice with timestamp, functionality and duration of execution. 


