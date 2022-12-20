export class ChuckNorris {
    private url: string = "https://api.chucknorris.io/jokes/random?category="

    public constructor() {
        
    }

    public async getJoke(category: string): Promise<string> {
        let newUrl: string = this.url + category
        let res = await fetch(newUrl)
        if (res.ok) {
            return (await res.json()).value
        } else {
            return ""
        }
    }
}