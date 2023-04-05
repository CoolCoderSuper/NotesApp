/** @type {import('./$types').PageLoad} */
export async function load({ fetch, params }) {
    const res = await fetch(`https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes`);
    const item = await res.json();
   
    return { notes: item };
}