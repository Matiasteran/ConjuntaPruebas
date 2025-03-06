Feature: Insert

Ingreso de la informacion del formulario cliente a la base de datos

@tag1
Scenario: Insertar Clientes
	Given El usuario esta en la pagina
	When Llenar los campos dentro del Formulario
		| Cedula     | Apellidos   | Nombres        | FechaNacimiento | Mail          | Telefono   | Direccion    | Estado |
		| 1726203936 | Garcia Jara | Luis Sebastian | 2003-04-10      | luis@test.com | 0987654321 | Guayllabamba | 1      |
	And Dar click en el boton de guardar
		| Cedula     | Apellidos   | Nombres        | FechaNacimiento | Mail          | Telefono   | Direccion    | Estado |
		| 1726203936 | Garcia Jara | Luis Sebastian | 2003-04-10      | luis@test.com | 0987654321 | Guayllabamba | 1      |
	Then El resultado se ve reflejado en la tabla
		| Cedula     | Apellidos   | Nombres        | FechaNacimiento | Mail          | Telefono   | Direccion    | Estado |
		| 1726203936 | Garcia Jara | Luis Sebastian | 2003-04-10      | luis@test.com | 0987654321 | Guayllabamba | 1      |


