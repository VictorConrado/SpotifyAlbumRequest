import { useState } from "react";

export default function App() {
  const [albums, setAlbums] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const API_BASE = import.meta.env.VITE_API_BASE;

  async function fetchAlbums() {
    setLoading(true);
    setError("");

    try {
      const response = await fetch(`${API_BASE}/spotify/api/albums`);
      if (!response.ok) throw new Error(`Erro HTTP ${response.status}`);

      const data = await response.json();
      setAlbums(data);
    } catch (err) {
      setError(err.message);
    }

    setLoading(false);
  }

  return (
    <div className="min-h-screen bg-gradient-to-b from-black to-gray-900 text-white p-8 flex flex-col items-center">

      {/* Container Central */}
      <div className="w-full max-w-3xl">

        {/* Título */}
        <h1 className="text-4xl font-extrabold mb-2 text-center">
           Obter Álbuns - Spotify API
        </h1>

        <p className="text-gray-400 text-center mb-8">
          Consumo da sua API .NET com um visual inspirado no Spotify
        </p>

        {/* Botões */}
        <div className="flex justify-center gap-4 mb-8">
          <button
            onClick={fetchAlbums}
            disabled={loading}
            className="px-6 py-2 bg-emerald-500 hover:bg-emerald-400 text-black font-semibold rounded-full shadow-lg transition transform hover:-translate-y-1"
          >
            {loading ? "Carregando..." : "Carregar Álbuns"}
          </button>

          <button
            onClick={() => setAlbums([])}
            className="px-6 py-2 bg-gray-700 hover:bg-gray-600 text-white font-semibold rounded-full shadow-md transition transform hover:-translate-y-1"
          >
            Limpar
          </button>
        </div>

        {/* Erro */}
        {error && (
          <p className="text-red-400 text-center mb-4">{error}</p>
        )}

        {/* LISTA */}
        <div className="grid grid-cols-1 sm:grid-cols-2 gap-6">
          {albums.map((album) => (
            <div
              key={album.id}
              className="bg-gray-800/40 backdrop-blur-md rounded-xl p-5 shadow-lg border border-gray-700 hover:border-emerald-400 transition transform hover:-translate-y-1 hover:shadow-emerald-600/30"
            >
              {/* Placeholder da capa */}
              <div className="w-full h-40 bg-gradient-to-br from-gray-700 to-gray-600 rounded-xl flex items-center justify-center mb-4 shadow-inner">
                <span className="text-5xl font-bold text-gray-300">
                  {album.name[0]}
                </span>
              </div>

              {/* Nome */}
              <h3 className="text-lg font-semibold truncate">{album.name}</h3>

              {/* Data */}
              <p classname="text-sm text-gray-400 mt-1">
                Lançamento: {new Date(album.release_date).toLocaleDateString()}
              </p>
            </div>
          ))}
        </div>

        {/* Estado vazio */}
        {albums.length === 0 && !loading && (
          <p className="text-gray-500 text-center mt-12">
            Nenhum álbum carregado ainda.
          </p>
        )}
      </div>
    </div>
  );
}
