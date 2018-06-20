<Query Kind="Statements">
  <Connection>
    <ID>68066941-d6a9-43fb-8c89-03cc79defa5f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>ServicuerosMVC</Database>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPmUmL14sJEC5goqZWRcHDwAAAAACAAAAAAAQZgAAAAEAACAAAAC1vPg3Zj7LEd8bMSh78c5lsVUPPqJ4k3wFLD2GaAWCVAAAAAAOgAAAAAIAACAAAAAb39y4/mmpgRoXIvBKsJ4LHub0xphCEIjwiC9U95dNQxAAAADQBY5ZCb5Lkl3NRPTGHJkXQAAAAFDhRG7ZzCLGzCvsD66rUUv5NVSi3stD9NCfMU1KwY45HYuJn9pY3IqE3AJO78CdWJabpGEl+fW1cbbczz8onTo=</Password>
  </Connection>
</Query>

var datos = (from l in Lotes
  					   join b1 in Bodega1s on l.LoteId equals b1.LoteId
                       join p in Pelambres on b1.Bodega1Id equals p.PelambreId
					   join f in Formulas on p.FormulaId equals f.FormulaId
					   join c in Componentes on f.FormulaId equals c.FormulaId
					   select new 
					   {
					   l.LoteId,
					   b1.NumeroPieles, b1.NumeroEstanteria, b1.Medida,
					   p.Activo,
					   f.Nombre, f.TipoPiel,
					   c.Cantidad, c.Detalle
					   });