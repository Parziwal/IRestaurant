export interface PagedList<T> {
    pageCount: number;
    totalItemCount: number;
    pageNumber: number;
    pageSize: number;
    result: Array<T>;
}