import PaginationButton from "../../shared/PaginationButton";
import Invoice from "./Invoice";

export default function InvoiceList() {

    return (
        <div className="col-lg-8">
            <table className="table mb-4 mt-2">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">First</th>
                        <th scope="col">Last</th>
                        <th scope="col">Handle</th>
                    </tr>
                </thead>
                <tbody>
                    {Array(8).fill(0).map(x => <Invoice />)}
                </tbody>
            </table>
            <nav aria-label="...">
                <ul className="pagination">
                    <li className="page-item disabled">
                        <a className="page-link">Previous</a>
                    </li>
                    {Array(3).fill(0).map(x => <PaginationButton />)}
                    <li className="page-item">
                        <a className="page-link" href="#">Next</a>
                    </li>
                </ul>
            </nav>
        </div>
    )
}