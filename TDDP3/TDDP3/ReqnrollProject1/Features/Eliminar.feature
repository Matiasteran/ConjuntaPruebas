Feature: Eliminar

Se elimina un usuario

@tag1
Scenario: Se verifica el delete de un usuario
	Given El usuario esta en la pagina para hacer el crud-delete
	When Se da click en el boton de eliminar
	Then Verificar la url de la pagina final

