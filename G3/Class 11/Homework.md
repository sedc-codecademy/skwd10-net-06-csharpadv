## Reimplementing the `tree` command

There is a command-line command in Windows called [`tree`](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/tree) that displays the directory or file structure of a given folder.

Your task, should you choose to accept it, is to replicate it's functionallity. The end result should be a command line program, that, when started, will output the files and folders within a certain folder.

The files and folders should be colored with different colors. Files and folders of a different depth should be indented accordingly.

As an example, if the target folder contains the following structure

- folder-one, which contains
    - folder-one-one, which contains
        - file-one-one-one.txt
        - file-one-one-two.txt
    - folder-one-two, which contains
        - file-one-two-one.txt
    - folder-one-three, which is empty
- folder-two, which contains
    - file-two-one.txt
    - file-two-two.txt
    - file-two-three.txt

the output of the command should look like:

```
.
+---folder-one
|    +---folder-one-one
|    |   +---file-one-one-one.txt
|    |   \---file-one-one-two.txt
|    +---folder-one-two
|    |    \---file-one-two-one.txt
|    \---folder-one-three
\---folder-two
    +---file-two-one.txt
    +---file-two-two.txt
    \---file-two-three.txt
```

If your output differs a bit from this, it is acceptible, as long as the structure is distinctly visible.

The application should take up to two command line parameters

- if the application is started with no parameters, then it will mork in the current folder, and it will output the result to the console.
- if the application is started with a single parameter, then it will treat that parameter as a folder name, and list all the files and folders within it. If the parameter is not a name of a folder, it will issue a corresponding error. The output should be shown on the console.
- if the application is started with two parameters, then it will treat the first parameter as a folder name, and list all the files and folders within it. If the parameter is not a name of a folder, it will issue a corresponding error. The second parameter should be the full name of a file where the output will be stored. If the file specified in the second parameter already exists, the application should issue a corresponding error.
- if the application is started with more than two parameters, it should issue a corresponding error.
