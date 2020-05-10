import { Observable } from 'rxjs';

export abstract class Pagination<TItem> {

    constructor(private getItemsCallback: (offset: number, count: number) => Observable<Items<TItem>>) { }

    protected _itemsCount: number = 0;
    protected _itemsPerPage: number = 15;

    protected _currentPage: number = 0;
    public items: TItem[] = [];

    public openPage(page: number) {
        this.getItemsCallback(this.getOffset(page), this.itemsPerPage)
            .subscribe((items: Items<TItem>) => {
                this.items = items.itemsModels;
                this._itemsCount = items.itemsCount;
                this._currentPage = page;
            });
    }

    public get pagesNumber(): number {
        return Math.ceil(this._itemsCount / this._itemsPerPage);
    }
    public get isFirstPage(): boolean {
        return this._currentPage == 0;
    }
    public get isLastPage(): boolean {
        return this._currentPage == this.pagesNumber - 1;
    }

    protected getOffset(page: number) : number {
        return page * this._itemsPerPage;
    }

    public get currentPage(): number {
        return this._currentPage;
    }
    public get itemsCount(): number {
        return this._itemsCount;
    }
    public get itemsPerPage(): number {
        return this._itemsPerPage;
    }
}

export class Items<TItem>{
    public itemsCount: number;
    public itemsModels: TItem[];
}