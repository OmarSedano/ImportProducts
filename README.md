This repository contains the code of a console application ImportProducstApp that reads products from differents sources (capterra and softwareadvice) as well as the Database querys


## ImportProducstApp

### Testing ImportProducstApp executable

To test the application executable you can go to the Application folder (if you don't see it, go to Folder View). There is the file 'import.exe' that is an executable, also you will see the folder 'feed-products' where there are the files "capterra.yaml" and "softwareadvice.json".

- Open a command prompt inside the Application folder
- Write the following command : "import capterra feed-products/capterra.yaml". You will see that the Capterra products are imported
- Press Control + K to exit the program
- Write the following command : "import softwareadvice feed-products/softwareadvice.json". You will see that the SoftwareAdvice products are imported

### Testing ImportProducstApp solution in Visual Studio

You can also execute ImportProducstApp from Visual Studio and debug it for example. Inside the project ImportProductsApp go to folder Properties ang open the file launchSettings.json. In this file you will see the following line:
"commandLineArgs": "capterra feed-products/capterra.yaml". Automatically sets the command line arguments. In case you want to test softareadvice you should change it.


### ImportProducstApp

The solution has two projects the ImportProducstApp project where is the coode of the program. In the future this code could be moved to another project to separate the Business Logic from the Console Application itself.
Also there is a project called ImportProductsTests where there are the tests. They are unit tests of the main classes. With more time i would have tested the class ProductServiceType and other classes. Also i would add Functional testing, for example, a test hat runs a Console Application process and tries to import products
In order to be database implementation agnostic, there are IProducRepository and ProductRepository. Also if in the future we want to adde a new source of products the only thing that we will have to do is to add a new class NewProductSourceService that inherits from IProductService and to add also the corresponding logic to the class ProductServiceType. Also we should register NewProductSourceService in the Startup 

## Database results
The database querys results can be found in the top level, in the file Database_querys.md

