/**
 * @description: Interface of flights
 */
export interface Flight {
  origin: string,
  destination: string,
  bagquantity: number,
  userquantity: number,
  flightid: string,
  departure: string,
  arrival:string
  price:number,
  stops:[],
  gate: number,
  status: string,
  discount: number,
  planeid: string,
  workerid: number
}
