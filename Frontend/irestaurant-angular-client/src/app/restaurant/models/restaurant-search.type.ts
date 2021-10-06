import { Page } from "src/app/shared/models/page.type";

export interface RestaurantSearch extends Page {
    nameOrShortDescriptionOrCity: string;
    sortBy: string;
}