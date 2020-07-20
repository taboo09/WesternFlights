export interface BookedFlight{
    customerName: string;
    seat: string;
    bookedFlightId: number;
    flightCode: string;
    departureAirport: string;
    departureDate: Date;
    arrivalAirport: string;
    arrivalDate: Date;
    price: number;
}