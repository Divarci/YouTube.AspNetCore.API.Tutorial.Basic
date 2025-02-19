import CompanyInfo from "./components/CompanyInfo"
import InvoiceList from "./components/InvoiceList"

export default function Main() {
    return (
        <main className="mt-2">
            <div className="row d-flex">
                <CompanyInfo />
                <InvoiceList />
            </div>
        </main>
    )
}