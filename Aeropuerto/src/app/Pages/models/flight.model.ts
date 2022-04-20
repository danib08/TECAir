export interface FlightModel {
  origin: string,
  destination: string,
  bagquantity: number,
  userquantity: number,
  flightid: string,
  departure: string,
  arrival:string
  price:number,
  stops:[],
  gate: string,
  status: string,
  discount: number,
  planeid: string,
  workerid: number
}
