import {Component} from "@angular/core";
import {CategoryService} from "../services/category.service"

@Component({
    selector: "category",
    template:`
      <h1>{{categoryName}}</h1>
      <p><strong>ID:</strong> {{categoryID}}</p>
      <button class="btn btn-primary" (click)="toggleDescription()">{{showDescription ? "Hide discription" : "Show description"}}</button>
      <div *ngIf="showDescription">
            <p><strong>Description:</strong> {{description}}</p>
      </div>
      <h3>Comments</h3>
      <ul>
         <li *ngFor="let comment of comments; let i = index">
            {{comment}}<button (click)="deleteComment(i)">X</button>
         </li>  
      </ul>
      <form (submit)="addComment(comment.value)" >
        <label>Add comment: </label>
        <input type="text" #comment />
        <input type="submit" value="Add" class="btn btn-primary">      
      </form>
  
      <hr/>
      <h3>Edit Category</h3>
      <form>  
        <label>Category name: </label>
        <input type="text" name="categoryName" [(ngModel)]="categoryName" />
        <br/>  
        <label>Description: </label>
        <input type="text" name="description" [(ngModel)]="description" />
        <br/>
      </form>             
    `,
    providers: [CategoryService]
})

export class CategoryComponent {
    categoryID: string;
    categoryName: string;
    description: string;
    picture: picture;
    showDescription: boolean;
    comments: string[];
    categories: Category[];

    constructor(private categoryService: CategoryService) {
        this.categoryID= '1';
        this.categoryName = 'Beverages';
        this.description = 'Soft drinks, coffees, teas, beers, and ales';
        this.picture = {
            hexcode: '0x151C2F00020000000D000E0014002100FFFFFFFF4269746D617020496D616765005061696E742E5069637475726500010500000200000007000000504272757368000000000000000000A0290000424D98290000000000005600000028000000AC00000078000000010004000000000000000000880B0000880B000008000000'
        }
        this.comments = ['I love Lager beer', 'My grandma like teas'];

        this.categoryService.getCategories().subscribe(categories => {
            console.log(categories);
        });
    }

    toggleDescription() {
        if (this.showDescription) {
            this.showDescription = false;
        } else {
            this.showDescription = true;
        }   
    }

    addComment(comment: string) {
        this.comments.push(comment);    
    }

    deleteComment(i: number) {
        this.comments.splice(i, 1);
    }

    getSrc(str: string) {
        return 'data:image/gif;base64,' + this.hexToBase64(this.picture.hexcode)
    }

    hexToBase64(hexstring: string) {
            return btoa(hexstring.match(/\w{2}/g).map(function (a) {
                return String.fromCharCode(parseInt(a, 16));
        }).join(""));
    }        
}

interface picture {
    hexcode: string    
}

interface Category {
    categoryID: string;
    categoryName: string;
    description: string;
    picture: picture;
}