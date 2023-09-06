using GeneralData.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http.Cors;

namespace GeneralData.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class pedidoController : ControllerBase
    {
        [HttpGet, Route("All")]
        [Authorize]
        public string AllPedidos()
        {
            Pedido myPedido = new Pedido();
            return myPedido.AllPedidos();
        }

        [HttpGet, Route("bySucursal")]
        [Authorize]
        public string bySucursal(string sucursal)
        {
            Pedido myPedido = new Pedido();
            return myPedido.OneBySucursal(sucursal); // NO SE COMO PASAR LA SUCURSAL DESDE USUARIO
        }



        [HttpPost, Route("create")]
        [Authorize]
        public IActionResult createPedido([FromBody] Model.Pedido pedido)
        {
            try
            {
               pedido.New(pedido.estado, pedido.id_usuario, pedido.nombre_cliente, pedido.factura_electronica, pedido.detalle_factura, pedido.metodo_envio, pedido.direccion_envio, pedido.urgencia, pedido.tipo_pedido);
               return Ok(new { Respuesta = "Se ha creado con exito el pedido.", pedido });                   
            }
            catch (Exception)
            {
                return Ok(new { Respuesta = "Error al ejecutar el endpoint" });
            }
        }
         


        [HttpPut, Route("update")]
        [Authorize]
        public IActionResult updatePedido([FromBody] Model.Pedido pedido)
        {
            try
            {

                pedido.Update(pedido.id_pedido, pedido.estado, pedido.id_usuario, pedido.nombre_cliente, pedido.factura_electronica, pedido.detalle_factura, pedido.metodo_envio, pedido.direccion_envio, pedido.urgencia, pedido.tipo_pedido);
                return Ok(new { Respuesta = "Se ha creado con exito el pedido.", pedido });

            }
            catch (Exception)
            {
                return Ok(new { Respuesta = "Error al ejecutar el endpoint" });
            }
        }



        [HttpDelete, Route("delete")]
        [Authorize]
        public IActionResult deletePedido([FromBody] Model.Pedido pedido)
        {
            try
            {
                pedido.Delete(pedido.id_pedido);
                return Ok(new { Respuesta = "Se ha eliminado el pedido correctamente" });

            }
            catch (Exception)
            {
                return Ok(new { Respuesta = "Error al ejecutar el endpoint" });
            }
        }

    }
}
