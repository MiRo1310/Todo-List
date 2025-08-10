import {config} from "../../config/config.ts";

type Endpoint = "count" | "delete" | "search" | "due" | "status" | "update" | "clear"
type Method = "GET" | "POST" | "PUT" | "DELETE";
export const request = async ({endpoint, method = "GET", body}: {
    endpoint?: Endpoint,
    method?: Method,
    body?: unknown
}) => {

    let url = config.url
    if (endpoint) {
        url += `${endpoint}`;
    }
    console.log(url, {
        method,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    })

    return await fetch(url, {
        method,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    })
        .then(response => {
            console.log('response', response);
            return response.json()
        })
        .then(data => {
            return data
        })
        .catch(error => {
            console.error('Fehler:', error)
        })

}