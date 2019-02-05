using ProductosService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductosService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProduct" in both code and config file together.
    [ServiceContract]
    public interface IServiceProduct
    {
        [OperationContract]
        bool CrearCategoria(Categoria categoria);

        [OperationContract]
        bool ActualizarCategoria(Categoria categoria);

        [OperationContract]
        bool EliminarCategoria(int id);

        [OperationContract]
        List<Categoria> ListarCategorias();

        [OperationContract]
        Categoria VerCategoria(int id);

        [OperationContract]
        bool CrearProducto(Producto producto);

        [OperationContract]
        bool ActualizarProducto(Producto producto);

        [OperationContract]
        bool EliminarProducto(int id);

        [OperationContract]
        List<Producto> ListarProductos();

        [OperationContract]
        Producto VerProducto(int id);

        [OperationContract]
        List<Producto> Filtrar(string parametro); 
    }
}
