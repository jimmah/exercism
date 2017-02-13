defmodule Exercism.Mixfile do
  use Mix.Project

  def project do
    [app: :tests,
     version: "0.0.1",
     elixir: "~> 1.3",
     test_paths: ["."],
     consolidate_protocols: false,
     deps: deps()]
  end

  def application do
    [applications: [:logger]]
  end

  defp deps do
    [{:poison, "~> 1.4.0"}]
  end
end