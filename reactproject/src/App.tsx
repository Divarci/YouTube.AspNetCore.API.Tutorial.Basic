import './App.css'
import Footer from './components/footer/Footer'
import Header from './components/header/Header'
import Main from './components/main/Main'
import CompanyInfoContextProvider from './contexts/CompanyInfoContext'

export default function App() {
    return (
        <CompanyInfoContextProvider>
            <Header />
            <Main />
            <Footer />
        </CompanyInfoContextProvider>
    )
}


