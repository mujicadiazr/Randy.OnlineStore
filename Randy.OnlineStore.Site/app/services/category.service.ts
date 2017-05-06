import {Injectable} from "@angular/core";
import {Http} from "@angular/http";
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

@Injectable()
export class CategoryService {
    constructor(private http: Http) {
        console.log('Category service initialized...');         
    }

    getCategories() {
        return this.http.get('http://localhost:52709/api/Category')
            .map(res => res.json());
    }
}