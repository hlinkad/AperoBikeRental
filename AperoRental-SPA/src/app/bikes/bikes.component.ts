import { Component, OnInit } from "@angular/core";
import { Bike } from "./bike";
import { BIKES } from "../mock-bikes";

@Component({
  selector: "app-bikes",
  templateUrl: "./bikes.component.html",
  styleUrls: ["./bikes.component.css"]
})
export class BikesComponent implements OnInit {
  bikes = BIKES;

  selectedBike: Bike;
  onSelect(bike: Bike): void {
    this.selectedBike = bike;
  }

  constructor() {}

  ngOnInit() {}
}
