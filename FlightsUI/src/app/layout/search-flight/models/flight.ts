export interface Flight{
    flightId: number;
    flightCode: string;
    departureAirportName: string;
    arrivalAirportName: string;
    departureDateTime: Date;
    arrivalDateTime: Date;
    price: number;
    maxNumberSeats: number;
    availableSeats: number;
}