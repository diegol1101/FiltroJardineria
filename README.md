

consulta 1
en esta consulta podemos ver el codigo de pedido, codigo del cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.

http://localhost:5005/api/Pedido/PedidosNoEntregadosATiempo


consulta 2
podemos ver el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina ala que pertenece el representante

http://localhost:5005/api/Cliente/ObtenerClientesNoPagosYRepresentantesConCiudadOficina

consulta 3
devuelve un listado donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algun cliente que haya realizado la compra de algun producto de la gama frutales 

http://localhost:5005/api/Oficina/OficinasNoEmFrutales

consulta 9
devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado

http://localhost:5005/api/Cliente/EmpleadosSinClientesConJefe

