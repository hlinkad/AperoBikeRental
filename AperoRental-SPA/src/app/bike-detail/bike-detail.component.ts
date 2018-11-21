import { Component, OnInit, Input } from "@angular/core";
import { Bike } from "../bikes/bike";
@Component({
  selector: "app-bike-detail",
  templateUrl: "./bike-detail.component.html",
  styleUrls: ["./bike-detail.component.css"]
})
export class BikeDetailComponent implements OnInit {
  @Input() bike: Bike;

  constructor() {}

  ngOnInit() {}
}
