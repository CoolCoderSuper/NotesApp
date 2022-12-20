export class Message
{
    private url: string = "https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5112.preview.app.github.dev/Messages"
    public content: string = ""
    public constructor(content: string){
        this.content = content
    }
    /**
     * Gets all the messages
     */
    public async getMessages(): Promise<Array<Message>> {
        /*let res = await fetch(this.url)
        if (res.ok)
        {
            return await res.json()
        }else
        {
            return [];
        }*/
        return [new Message("Hi"), new Message("Bye")]
    }
}