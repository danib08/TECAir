export interface FlightModel {
  Origin: string,
  Destination: string,
  BagQuantity: number,
  UserQuantity: number,
  FlightID: string,
  Departure: string,
  Arrival:string
  Price:number,
  Stops:[],
  Gate: string,
  Status: string,
  Discount: number,
  PlaneID: string,
  WorkerID: number
}
