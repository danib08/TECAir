/**
 * @description: Interface of flights
 */
export interface Flight {
  Flightid: string,
  BagQuantity: number,
  UserQuantity: number,
  Gate: number,
  DepartureTime: string,
  ArrivalTime:string,
  Origin: string,
  Destination: string,
  Stops:string,
  Status:string,
  Price:number,
  Discount:number,
  Planeid: string,
  Workerid: number,
}
