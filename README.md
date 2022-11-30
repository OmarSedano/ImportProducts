This repository contains the code of a console application ImportProducstApp that reads products from differents sources (capterra and softwareadvice). It contains as well the Database querys answers for the Database part of the test. 


## ImportProducstApp

### Testing ImportProducstApp executable

To test the application executable you can go to the Application folder (if you don't see it, go to Folder View). There is the file 'import.exe' that is an executable, also you will see the folder 'feed-products' where there are the files "capterra.yaml" and "softwareadvice.json".

- Open a command prompt inside the Application folder
- Write the following command : "import capterra feed-products/capterra.yaml". You will see that the Capterra products are imported
- Press Control + C to exit the program
- Write the following command : "import softwareadvice feed-products/softwareadvice.json". You will see that the SoftwareAdvice products are imported

### Testing ImportProducstApp solution in Visual Studio

You can also execute ImportProducstApp from Visual Studio and debug it for example. Inside the project ImportProductsApp go to folder Properties ang open the file launchSettings.json. In this file you will see the following line:
"commandLineArgs": "capterra feed-products/capterra.yaml". Automatically sets the command line arguments. In case you want to test softareadvice you should change it.


### ImportProducstApp

The solution has two projects the ImportProducstApp project where is the code of the program. In the future this code could be moved to another project to separate the Business Logic from the Console Application itself.

The central service is called ImportProductService. It is the entry point to the business logic. 
The first thing that does is to call "productServiceFactory(source)". It is a factory method that will resolve the IProductService interface between CapterraService and SoftwareAdviceService. To do that this factory is registered in the Program.cs in .AddTransient(ProductServiceFactory) ans uses the ProductServiceType class. It will allows us in the future, if we need to add a new soruce, to just add a new implementation that inherits from IProductService and to modify the class ProductServiceType to add the case. 
The second thing is to call productService.GetProducts(sourcePath) to obtain the products formatted.
The last thing is to call productsRepository.SaveAsync(products) to save the products. In order to be the service database logic agnostic, we inject IProducRepository. If we decide to change from for example Sql to MongoDb the only class we will need to  modify is ProductRepository.

Also there is a project called ImportProductsTests where there are the tests.They are unit tests of the main classes. 
With more time i would have tested the class ProductServiceType and other classes. Also i would add Functional testing, for example, a test that runs a Console Application process and tries to import products

## Database results
The database querys results can be found in the top level, in the file Database_querys.md

