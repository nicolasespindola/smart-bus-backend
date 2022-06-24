
# Smart Bus (Backend)

Esta aplicacion de .Net 5 provee el servicio web necesario para la aplicacion
Smart Bus Mobile.


## Instalacion

- Instalar [Visual Studio](https://visualstudio.microsoft.com/es/vs/community/)

- Instalar [MSSQL Server Management Studio](https://aka.ms/ssmsfullsetup)
  
  - Para ingresar en el server local asegurarse de usar esta configuracion:
    
    ![](https://i.imgur.com/QipwaIM.png)

  - Abrir el proyecto en Visual Studio y dentro del proyecto SmartBus.Database dar doble click al archivo **SmartBus.Database.publish.xml**
    
    ![](https://i.imgur.com/5srA1TF.png)

  - Presionar publish

    ![](https://i.imgur.com/BY3KEH0.png)

  - Con esto se creara en nuestro servidor local SQL una nueva base con el nombre **smart-bus-database** junto con sus tablas y datos iniciales
    
    ![](https://i.imgur.com/nPUOkvj.png)

- Dentro de Visual Studio buscar e instalar la extension [Conveyor](https://conveyor.cloud/Home/How_To_Install)
  (Seguir la guia hasta el paso 4)
  
