import { useCallback, useContext, useEffect, useState } from "react";
import { CompanyInfoContext } from "../contexts/CompanyInfoContext";

type Client = {
    id: number,
    companyName: string,
    address: string,
    owner: string,
    phone: string
}

type Result = {
    data: Client[],
    statusCode: number,
    errors: string[]
}

export default function useFetch<T>(url: string, config: RequestInit) {
    const [result, setResult] = useState<T | null>()
    const [error, setError] = useState<string | null>(null)
    const [isLoading, setIsloading] = useState(false)
    const context = useContext(CompanyInfoContext)

    if (!context)
        throw new Error()

    const { setClients } = context


    const SendRequest = useCallback(
        async (postData: BodyInit | null) => {
            setIsloading(true);

            try {
                const response = await fetch(
                    url,
                    { ...config, body: postData === null ? null : postData })

                const resData: T = await response.json()

                if (!response.ok) {
                    throw new Error("Request error")
                }

                setResult(resData)

                if (config && config.method === 'GET') {
                    const result = resData as Result

                    setClients(result.data)
                }               
            } catch (error) {
                if (error instanceof Error)
                    setError(error.message)
            }

            setIsloading(false);
        }, [url, config])
            
    return {
        result,
        isLoading,
        error,
        SendRequest
    }
}


