Feature: Editar

Editar algun usuario

@tag1
Scenario: Se edita un usuario
	Given El usuario esta en la pagina para hacer el crud-editar
	When Llenar los campos dentro del Formulario editar
		| Cedula     | Apellidos   | Nombres     | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
		| 1726203936 | Reyes Ceron | Ariel Reyes | 2003-04-10      | ariel@test.com | 0987654321 | Lloa      | 1      |
	And Dar click en el boton de guardar del formulario editar
	Then Verificar la url de la pagina

