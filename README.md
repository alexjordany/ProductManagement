## Administración de productos  
  



### Cambiar variable de entorno  
Para usar las cadenas de conexión es necesario cambiar las variables de entorno en Visual Studio, por defecto su valor es Development, al cambiarlo a cualquier otro permitirá usar las cadenas de conexión en appsettings.json  
  



### Cadenas de conexión  
Modificar en ProductManagement.API el archivo appsettings.json para ajustar las cadenas de conexión según sea necesario  
  



### Comandos  
Usando la terminal, navegar hasta la raíz de la solución (donde esta el archivo ProductManagement.sln) y ejecutar  
  

Use los siguientes comandos en la terminal o tambien dentro de visual studio con la ventana de administración de paquetes, los comandos debajo son para .net CLI en la terminal/consola.
   
  

- dotnet ef database update --project ProductManagement.Persistence --startup-project ProductManagement.API -—context ProductManagementPersistenceDbContext  
  

- dotnet ef database update --project ProductManagement.Identity --startup-project ProductManagement.API -—context ProductManagementIdentityDbContext  
  



### Registro de usuario  
Terminado los pasos anteriores y ejecutar el API se debe registrar usando el endpoint Register, la contraseña debe contener una mayúscula, un símbolo y un numero.  
  



### Generar token  
Para generar el token, use el endpoint authenticate, use el correo y contraseña que uso para registrarse en el paso anterior.  
  



### Usando el token  
Copie el token generado en el paso anterior sin comillas y presione el botón verde de Authenticate, en el campo token escriba Bearer espacio token, por ejemplo: Bearer 12345abcdefg  
  

Una vez autenticado puede hacer uso de los endpoints del API  

<br />
